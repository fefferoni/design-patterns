## Strategy pattern to handle different file formats when serializing/deserializing objects. 
This is a simplified version of an implementation of the strategy pattern that I created for a project where i needed to read and write some parameters to both XML- and JSON files.
There is a strategy for JSON and for XML. Strategies for other file types can easily be added without violating the open/close principle.

Because I occasionally needed to get the file contents as a plain string I also implemented a method for this in an abstract base class (this code would be the same regardless of the file format).