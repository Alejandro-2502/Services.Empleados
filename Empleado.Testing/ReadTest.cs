using AutoMapper;
using Empleado.Application.DTOs;
using Empleado.Application.IComon;
using Empleado.Application.Responses.Empleado;
using Empleado.Application.Services.Empleado;
using Empleado.Domain.Interfaces;
using Empleado.Entity.Entitys;
using Moq;
using System.ComponentModel;
using System.Net;

namespace Empleado.Testing;

[TestClass]
public sealed class ReadTest
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ILogServices> _logServicesMock;
    private readonly EmpleadoReadServices _empleadoReadServices;
    private readonly Mock<IEmpleadoRepository> _empleadoRepositoryMock;

    public ReadTest()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _logServicesMock = new Mock<ILogServices>();
        _empleadoRepositoryMock = new Mock<IEmpleadoRepository>();
        _unitOfWorkMock.Setup(u => u.empleadoRepository).Returns(_empleadoRepositoryMock.Object);

        _empleadoReadServices = new EmpleadoReadServices(_unitOfWorkMock.Object, _mapperMock.Object, _logServicesMock.Object);
    }

    [TestMethod]
    [Category("GetAllOk")]
    public async Task GetAllOKTest()
    {
        var resultDtoMock = ReadMock.GetAllQueryOk()  ;
        var resultResponseMock = ReadMock.GetAllResponseOk;

        _unitOfWorkMock.Setup(emp => emp.empleadoRepository.GetAllAsync()).ReturnsAsync(resultDtoMock.ToList());
        _mapperMock.Setup(map => map.Map<List<EmpleadoResponse>>(resultDtoMock)).Returns(resultResponseMock);

        var result = await _empleadoReadServices.GetAll();

        Assert.IsNotNull(resultDtoMock);
        Assert.IsTrue(result.Success);
        Assert.IsTrue(result.StatusCode.Equals(HttpStatusCode.OK));
    }

    [TestMethod]
    [Category ("GetByIdOk")]
    public async Task GetByIdOKTest()
    {
        var empleado = ReadMock.GetByIdEntityOk();
        var empleadoResponse = ReadMock.GetByIdResponseOk();

        _empleadoRepositoryMock.Setup(emp => emp.GetAsync(It.IsAny<int>()))
           .ReturnsAsync(empleado);

        _mapperMock.Setup(emp => emp.Map<EmpleadoResponse>(empleado))
            .Returns(empleadoResponse);

        var result = await _empleadoReadServices.GetById(It.IsAny<int>());

        Assert.IsNotNull(result);
        Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        Assert.AreEqual("Juan", result.Response.Nombre);
        Assert.AreEqual("Fernandez", result.Response.Apellido);
        Assert.AreEqual("Gerente", result.Response.Cargo);
        Assert.AreEqual(39, result.Response.Edad);
        Assert.AreEqual("fernandez@hotmail.com", result.Response.EMail);
    }

    [TestMethod]
    [Category("GetByIdNotFound")]
    public async Task GetByIdNotFound()
    {
        _empleadoRepositoryMock.Setup(emp => emp.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((EmpleadoEntity)null);

        var result = await _empleadoReadServices.GetById(It.IsAny<int>());

        Assert.IsNotNull(result);
        Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        Assert.IsFalse(result.Success);
    }

    [TestMethod]
    [Category("GetByEdadMayorIgualOk")]
    public async Task GetByEdadMayorIgualOk()
    {
        var empleadosEntity = ReadMock.GetByEdadMayorIgualEntityOk();
        var empleadosDTO = ReadMock.GetByEdadMayorIgualDTOok();
        var empleadoResponse = ReadMock.GetByEdadMayorIgualResponseOk();

        _unitOfWorkMock.Setup(repo => repo.empleadoRepository.GetByEdadMayotIgual(It.IsAny<int>()))
            .ReturnsAsync(empleadosEntity);
        _mapperMock.Setup(m => m.Map<List<EmpleadoDTO>>(empleadosEntity)).Returns(empleadosDTO);
        _mapperMock.Setup(m => m.Map<List<EmpleadoResponse>>(empleadosDTO)).Returns(empleadoResponse);

        var result = await _empleadoReadServices.GetByEdadMayorIgual(30);

        Assert.IsNotNull(result);
        Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        Assert.IsTrue(result.Messages.Count > 0);
    }
}
