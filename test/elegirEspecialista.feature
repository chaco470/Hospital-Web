Feature:  seleccionar especialista para turno 
Scenario: como usuario quiero poder elegir a mi especialista para ser tratado
Given un usuario elije la especialidad Hematología
When  hace click en continuar 
Then elije alguno de los especialistas que coinciden con la especialidad
    