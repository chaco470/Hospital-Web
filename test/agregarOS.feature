Feature: agregar una obra social
Scenario: como admin quiero agregar una obra social para que los usuarios puedan atenderse a travez de ella
Given  un admin agrega una obra social correctamente
When introduce los datos de la obra social y le da al boton de guardar
Then la obra social aparece en la seccion correspondiente