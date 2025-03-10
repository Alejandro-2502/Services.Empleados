# Services.Empleado
Un ejemplo de un servicio desarrollado en .Net se describe a continuacion las caracteristicas

Se implemento los siguientes patrones (UnitOfWork - Clean Arqchitect)
Se aplica Principios SOLID. Para el manejo, mantenimiento y acceso a la base de datos, se emplea OMR ( EntityFramework ) 
Ademas se aplica Inyeccion de Dependencias (DI) 
Tambien, se utiliza (FluentValidation), a fin de aplicar validaciones basicas a el INPUT de los request,utilizado en el controller ( EmpleadoWriteController )

El diseño empleado consta de las siguientes capas que se mencionan a continuación:

Capa Principal Servicio - (Presenter):

- La misma contiene distribuidos los controladores
  
  - EmpleadoReadController
  - EmpleadoWriteController
  
- Tambien se encuentra alojado las clases, propias de configuraciones de ( App y Services ). La idea de realizarlo asi, fue de mantener segmentada, 
  para mas entendimiento, las configuraciones requeridas, para esta Api Services. 
  
  - Extensiones :
	- IApplicationBuildExtension ( clase Statica )
	- IServiceCollectionExtensions ( clase Statica )
	- IInjectionsExtensions ( clase Statica )
	
Capa de aplicación:

Se encuentra toda la estructura que se podrá utilizar, dentro de las otras capas, si así fuese necesario. Dentro de esta capa, están alojados dentro de directorios, para un mayor ordenamiemto y disponibles lo siguiente:

	- Common
	- Configurations
	- DTOs
	- Genérics
	- ICommon
	- Interfaces
	- Mappers ( Automapper )
	- Request
	- Resources ( Se emplea archivos de recursos, para el contenido de los mensajes de validaciones y advertencias, que se puedan producir durante la ejecución del flujo )
	- Responces ( Clases creadas de tipo Genericas, para estandarizar, lo ma optimo posible, la salida a respuestas de las solicitudes de cada endponit )
	- Service ( Contiene la clase servicio, donde se implementa la Interfaz )
	- Validations

Capa Domain:

- Se encuentra la entidad ( Entitys en este caso, para el empleado ) 
- Las Interfaces vinculadas a los patrones mencionados 

	- IEmpleadoRepository
	- IRepository
	- IUnitOfWork ( Su interfaz ) 
	
Capa Infraestructura:

- Dentro de esta capa, se encuentra toda la estructura, que se empleará para la base de datos SQLServer. 
	- EmpleadoBuilder : ( Para la creación de la configuración de la tabla, que se creará en la DB ), con sus propiedades 
	- Context : ( El configurador de la conectividad a la base de datos, que se este utilizando, asignandole la ruta del ConectionString, como así también su correspondiente DBSet, para la entidad Cliente) 
	- Migrations : ( Los archivos, de migraciones, que se generan automáticamente cada vez que se ejecuta por consola PowerShell, los comandos de Add-Migration, Update-Database (Nombre Archivo Migracion) 
	- Repositorys: Las clases de servicios de repositorios, en donde se implementan las (Interfaces, creadas en la capa DOMAIN) 
		- EmpleadoRepository
		- Repository ( Contiene un Generic ( T )
	- UnitOfWork: La interfaz, donde se construye la configuración de las interfaces, menciona (IProductoCommandRepository y IProductoQuerysRepository)

Nota: Como una simple aclaracion, es tan solo un ejemplo, de una forma de muchas existentes, para realizar este desarrollo. 
		Es tan solo a modo de ejemplo

Saludos.! Gracias
