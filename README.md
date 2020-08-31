# Armadillo Game Engine
 A command line only output game engine designed to be simple and understandable extremely heavily influenced by Unity.
 
 The structure of the engine works as follows:
 
 The static ```Game``` class contains a list of ```GameObjects```. Each ```GameObject``` contains a list of components which implement ```IComponent```. Each frame the ```Update()``` method in the component is called. For example, a sprite is sent to the renderer or an input is read and an object moved. 

