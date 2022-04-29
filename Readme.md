[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://www.dotnetfoundation.org/)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt)
## SANTANDER CHALLENGE
* [General](#general)
* [StackTecnologico](#stacktecnologico)
* [API](#api)
* [SitioWEB](#sitioweb)

## General
 Challenge tecnico de meetups.

 * Historias de usuario
   -  Como administrador quiero saber cuántas cajas de birras tengo que comprar para aprovisionar la meetup.
   -  Como administrador y usuario quiero conocer la temperatura del día de la meetup para saber si hace calor o no.
   -  Como administrador y usuario quiero recibir notificaciones para estar al tanto de las meetups.
   -  Como administrador quiero armar una meetup para invitar a otras personas.
   -  Como usuario quiero inscribirme en una meetup para poder asistir.
   -  Como usuario quiero hacer check-in en una meetup para poder avisar que estuve ahí.

## StackTecnologico
- Proyecto creado con:
 * API .Net: versión 6.0
 * SwashBuclke.AspNetCore (Swagger tools): versión 6.2.3
 * Newtonsoft.Json: versión 13.0.1
 * Sitio web y clases en .NET framework 4.8


## API

* Configuraciones:

   Archivo de configuración:  /Datos/Keys.json (En clase ModelsClass)
   
  * API de clima:
     + "X-RapidAPI-Host": string
     + "X-RapidAPI-Key": string
  * Notificaciones de envió de mail:
     + "Cuenta": string
     + "NombreCompleto": string
     + "Servidor": string
     + "Puerto": int
     + "SSL": bool
     + "autenticacion": true
     +  "User": string
     +  "Pass": string

   Archivo de configuración: /Datos/ValidKeys.json (En clase ModelsClass)
   
   * Keys válidas para consumir las APIS: (Se debera agregar la key válida para consumir las apis.) 
     + "X-LNApi-Token": string

## SitioWEB

* Configuraciones:
 
  * web.config: Debe configurarse dentro de appSettings las key:
     + < add key="APIs" value="{HOST_API}" />: string con el valor de la url donde estan las apis.
     + < add key="APIsKey" value="{VALID_KEY}" />: string con el valor de una key válida para consumir las apis. (configurada en el archivo ValidKeys.json En la clase ModelsClass).


  * Manifest.json: Archivo de configuración para PWA.
     + Funciona el instalador desde un host con https.
     + 
 
  * Calculo de cajas: (La temperatura que se tiene en cuenta es la máxima del día ya que se prefiere que sobre y no que falte.)    
     + Si hace menos de 20° se toma 0.75 cerveza por persona.
     + Si hace de 20° a 24° se toma 1 cerveza por persona. 
     + Si hace más de 24° se toman 2 cervezas más por persona, sería un total de 3.
    
