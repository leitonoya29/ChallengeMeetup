[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://www.dotnetfoundation.org/)
[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/dotnet/aspnetcore/blob/main/LICENSE.txt)
## SANTANDER CHALLENGE
* [General](#general)
* [StackTecnologico](#stacktecnologico)
* [API](#api)
* [SitioWEB](#sitioweb)

## General
 Challenge tecnico.....

## StackTecnologico
Proyecto creado con:
* API .Net: -version: 6.0
* SwashBuclke.AspNetCore (Swagger tools) -version: 6.2.3
* Newtonsoft.Json -version: 13.0.1
* Sitio web y clases en .NET framework 4.8


## API

* Configuraciones:

Archivo de configuración: /Datos/Keys.json (En clase ModelsClass)

* API de clima:
 * "X-RapidAPI-Host": string
 * "X-RapidAPI-Key": string

* Notificaciones de envio de mail
 * "Cuenta": string
 * "NombreCompleto": string
 * "Servidor": string
 * "Puerto": int
 * "SSL": bool
 * "autenticacion": true
 * "User": string
 " Pass": string

Archivo de configuración: /Datos/ValidKeys.json (En clase ModelsClass)

* Keys validas para consumir las APIS:
 * Se debera agregar la key valida para consumir las apis.
  *  X-LNApi-Token.

## SitioWEB

* Configuraciones:
 
  - web.config: Debe configurarse dentro de appSettings las key:
     + < add key="APIs" value="{HOST_API}" />: string con el valor de la url donde estan las apis.
     + < add key="APIsKey" value="{VALID_KEY}" />: string con el valor de una key valida para consumir las apis. (configurada en el archivo ValidKeys.json En la clase ModelsClass).


  - Manifest.json: Archivo de configuracion para PWA.
     + Funciona el instalador desde un host con https.
     + 
 

