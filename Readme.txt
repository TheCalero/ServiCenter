<********* M: 03/06/17***********>
--Sobre WPF
#Moví HomePos.xaml desde EE a MM/POS/
#agregué nuevoProducto y egProducto a EE/
#actualizé inventariosPage de MM
#actualizé los archivos App .xaml .config . xaml.cs de la carpeta Cliente_WPF
--Sobre Modelo
#actualizé los archivos Precios, Inventarios .cs de la carpeta ServiCenter_Modelo
#actualizé el archivo Productos.cs de ServiCenter_Modelo
#borré Productoscs.cs de ServiCenter_Modelo (archivo repetido)
#al carajo, hay un monton de repetidos... Actualicé toda la carpeta de ServiCenter_Modelo
--Sobre WebService
#Borré Pedidos_service_impl de la carpeta App_Code
*lo siguiente es sobre el archivo Service.cs
#linea 224 metodo "return (int)objInventarios.agregar(inventarios);" pide dos parametros más, corregido (verificar si el objeto que se pasa ya tiene el id usuario)
#linea 245, 258 lo mismo
#linea 279 lo mismo, pero no sé qué usuario iba

#En resúmen, descargué todo el proyecto de nuevo, lo actualicé con lo que tenía y lo volví a subir. Además de alguna actualización (en mi proyecto local) entre ahorita a cuando se revise de nuevo, esta carpeta tendrá exactamente las mismas cosas que tengo en mi pc.
#Como nota, recomiendo desisntalar los paquetes NuGat (Uninstall-Package MaterialDesignThemes;Uninstall-Package MaterialDesignColors (si, temas y color son a parte :v)) y volverlos a instalar (Install-Package MaterialDesignThemes)
</********* M: 03/06/17***********>


<********* M: 03/06/17***********>
#homePos.xaml
#linea 32, 39 40 de Usuario_servicio_impl
#lineas del 63 al 71 de Iniciar.xaml.cs
#creé el archivo Nueva_Venta, listar_ventas
#Agregué las Paginas inventarios y clientes a MM.POS
Me parece que sólo yo hago esto...
</********* M: 04/06/17***********>

<********* M: 03/06/17***********>
modificado script sql: se agregó precio_prodducto a Detalle_ventas y otras cosishas
</********* M: 03/06/17***********>
