Feature: agregar una nota
Scenario: como admin quiero agregar una nota para mantener informado a los usuarios
Given  un admin agrega una nota correctamente
When llena los campos con la informacion y le da al boton de guardar
Then la nota se agrega a la pantalla del home