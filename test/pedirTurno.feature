Feature: pedir un turno
Scenario: como usuario quiero pedir un turno para ser atendido
Given  un usuario solicita un turno 
When presiona el boton de pedir turno
Then se agrega un turno
