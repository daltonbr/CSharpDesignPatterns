# Command Pattern

## Characteristics

* **Command** (I am the command)
* **Receiver** (the command runs me)
* **Invoker** (I run & keep track of the commands)
* **Client** (I decide what command to schedule)

![Characteristics](docs/Characteristics.png)

**A command contains all the data to process the request now or at a later time.**

## Example

AddToCartCommand

* The product which should be added to the cart
* The shopping cart
* A way to check stock availability

![Example1](docs/Examples1.png)
![Example2](docs/Examples2.png)

The command pattern  can easily be leveraged to allow **undo or redo** functionality.

**Repository pattern** (not covered here) let us work with storage without the consumer having to know about the specific data location (SQL, In-Memory, etc)
