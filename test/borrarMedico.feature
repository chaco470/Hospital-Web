Feature: borrar un medico 
Scenario: como admin quiero eliminar especialista para mostrar que ese especialista no atiende
Given  un admin se logea correctamente y ve sus medicos
When presiona el boton borrar y confirma el borrado 
Then el medico seleccionado ya no esta en la cartelera
