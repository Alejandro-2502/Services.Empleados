using AutoMapper;
using Empleado.Application.IComon;
using Empleado.Application.Intefaces.Validator;
using Empleado.Application.Requests.Empleado;
using Empleado.Application.Responses.Empleado;
using Empleado.Application.Services.Empleado;
using Empleado.Domain.Interfaces;
using Empleado.Entity.Entitys;
using Moq;
using System.ComponentModel;
using System.Net;

namespace Empleado.Testing
{
    [TestClass]
    public sealed class WriteTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogServices> _logServicesMock;
        private readonly Mock<IValidationsServices> _validationsServicesMock;
        private readonly EmpleadoWriteServices _empleadoWriteServices;

        public WriteTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _logServicesMock = new Mock<ILogServices>();
            _validationsServicesMock = new Mock<IValidationsServices>();
            _empleadoWriteServices = new EmpleadoWriteServices(_unitOfWorkMock.Object, _mapperMock.Object, _validationsServicesMock.Object, _logServicesMock.Object);
        }

        [TestMethod]
        [Category("AddOkTest")]
        public async Task AddOkTest()
        {
            var requestEmpleado = WriteMock.AddRequestOk();
            var entityEmpleado = WriteMock.AddEntityOk();
            var responseEmpleado = WriteMock.AddResponseOk();

            _validationsServicesMock.Setup(val => val.Validator(It.IsAny<EmpleadoRequest>())).ReturnsAsync(new List<string>());
            _mapperMock.Setup(map => map.Map<EmpleadoEntity>(requestEmpleado)).Returns(entityEmpleado);
            _unitOfWorkMock.Setup(emp => emp.empleadoRepository.AddAsync(It.IsAny<EmpleadoEntity>())).ReturnsAsync(entityEmpleado);
            _mapperMock.Setup(m => m.Map<EmpleadoResponse>(entityEmpleado)).Returns(responseEmpleado);

            var result = await _empleadoWriteServices.Insert(requestEmpleado);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Category("AddNullTest")]
        public async Task AddNullTest()
        {
            var request = new EmpleadoRequest { Nombre = "German" };
            var entity = new EmpleadoEntity { Nombre = "German", Apellido = "Benetton"};

            _validationsServicesMock.Setup(val => val.Validator(request)).ReturnsAsync(new List<string>());
            _mapperMock.Setup(map => map.Map<EmpleadoEntity>(request)).Returns(entity);
            _unitOfWorkMock.Setup(emp => emp.empleadoRepository.AddAsync(entity)).ReturnsAsync((EmpleadoEntity)null);

            var result = await _empleadoWriteServices.Insert(request);

            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
        }

        [TestMethod]
        [Category("UpDateTest")]
        public async Task UpDateTest()
        {

            var requestEmpleado = WriteMock.UpdateRequestOk();
            var entityEmpleado = WriteMock.UpdateEntityOk();
            var responseEmpleado = WriteMock.UpdateResponseOk();

            _validationsServicesMock.Setup(v => v.Validator(It.IsAny<EmpleadoRequest>())).ReturnsAsync(new List<string>());
            _mapperMock.Setup(m => m.Map<EmpleadoEntity>(requestEmpleado)).Returns(entityEmpleado);
            _unitOfWorkMock.Setup(repo => repo.empleadoRepository.UpdateAsync(It.IsAny<EmpleadoEntity>())).ReturnsAsync(entityEmpleado);
            _mapperMock.Setup(m => m.Map<EmpleadoResponse>(entityEmpleado)).Returns(responseEmpleado);

            var result = await _empleadoWriteServices.Update(requestEmpleado);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Success);
        }
    }
}
