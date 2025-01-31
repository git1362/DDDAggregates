# DDDAggregates
First Example is to practice base on this article Double Dispatch in C# and DDD
https://ardalis.com/double-dispatch-in-c-and-ddd/

# Reasoning Behind Choosing Aggregate Root
1.	__Encapsulation of Business Logic:__ By using aggregate roots, the solution encapsulates the business logic within the root entity. This ensures that all operations that modify the state of the aggregate go through the root, maintaining consistency and integrity.
2.	__Consistency Boundaries:__ Aggregate roots define consistency boundaries. For example, in the Gym class, the AddRoom method ensures that no more rooms than allowed by the subscription can be added. This prevents inconsistent states within the aggregate.
3.	__Simplified Data Access__: Aggregate roots simplify data access by providing a single entry point for interacting with the aggregate. This reduces the complexity of managing relationships between entities.
4.	__Transaction Management__: Operations on an aggregate are typically performed within a single transaction. This ensures that all changes within the aggregate are committed or rolled back together, maintaining atomicity.
