Feature: cancelar un turno
Scenario: como usuario quiero cancelar un turno por cualquier eventualidad
Given  un usuario solicita cancelar un turno 
When presiona el boton de cancelar turno
Then se pierde un turno
