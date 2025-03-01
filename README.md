#### Description of the principles used:

### Single Responsibility Principle
* Each class performs only one responsibility. [Food](./KPZ-Lab1/Program.cs#L38-L49) describes feed, [Enclosure](./KPZ-Lab1/Program.cs#L50-L60) manages the enclosures, etc.

### Open/Closed Principle
* [Employee](./KPZ-Lab1/Program.cs#L86-L96) is a base class, and new roles can easily be added without changing existing code.

### Liskov Substitution Principle
* [Zookeeper](./KPZ-Lab1/Program.cs#L98-L113) and [Veterinarian](./KPZ-Lab1/Program.cs#L115-L123) can be used in place of [Employee](./KPZ-Lab1/Program.cs#L86-L96) without changing the program logic.

### Interface Segregation Principle
* [IAnimal](./KPZ-Lab1/Program.cs#L3-L8) interface contains only the necessary properties for animals, without redundant methods that are not required for all animals.

### Program to Interfaces, not Implementations
* [Enclosure](./KPZ-Lab1/Program.cs#L50-L60) and [Inventory](./KPZ-Lab1/Program.cs#L125-L143) work with [IAnimal](./KPZ-Lab1/Program.cs#L3-L8), not specific implementations.

### Fail Fast
* [Enclosure.AddAnimal() ](./KPZ-Lab1/Program.cs#L62-L78) immediately checks for enclosure overflows and animal incompatibilities, preventing errors before they occur.

### YAGNI
* There are no unnecessary properties and methods in the classes that are not used. [Veterinarian](./KPZ-Lab1/Program.cs#L115-L123) contains only [Specialization](./KPZ-Lab1/Program.cs#L117), which is enough for our task.


