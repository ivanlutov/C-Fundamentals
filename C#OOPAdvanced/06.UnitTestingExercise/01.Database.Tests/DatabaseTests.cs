using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class DatabaseTests
{
    [Test]
    public void CtorShouldWorkWithCollection()
    {
        var database = new Database(new int[] { 1, 2, 3, 4, 5, 6 });

        Assert.AreEqual(6, database.Count());
    }

    [Test]
    public void CtorShouldWorkWithCollectionWithSixteenElements()
    {
        var database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

        Assert.AreEqual(16, database.Count());
    }

    [Test]
    public void CtorShouldWorkWithCollectionWithOneElement()
    {
        var database = new Database(new int[] { 1 });

        Assert.AreEqual(1, database.Count());
    }

    [Test]
    public void CtorShouldWorkWithCollectionWithZeroElement()
    {
        var database = new Database();

        Assert.AreEqual(0, database.Count());
    }

    [Test]
    public void CtorShouldNotAcceptMoreThan16Elements()
    {
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

        Assert.Throws<InvalidOperationException>(() => new Database(array));
    }

    [Test]
    public void CtorDoesntAcceptNullObject()
    {
        Assert.Throws<ArgumentNullException>(() => new Database(null));
    }

    [Test]
    public void AddMethodShouldAddOneElement()
    {
        var database = new Database();

        database.Add(2);

        Assert.AreEqual(1, database.Count());
    }

    [Test]
    public void AddMethodShouldAddManyElement()
    {
        var database = new Database();

        database.Add(2);
        database.Add(3);
        database.Add(4);
        database.Add(5);

        Assert.AreEqual(4, database.Count());
    }

    [Test]
    public void AddMethodShouldThrowExceptionWhenElementsInDatabaseAreEqualOrMoreThanCapacityOfDatabase()
    {
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        var database = new Database(array);

        Assert.Throws<InvalidOperationException>(() => database.Add(1));
    }

    [Test]
    public void AddMethodShouldAddElementAtNextFreeIndex()
    {
        var database = new Database();

        database.Add(1);
        database.Add(2);

        Assert.AreEqual(2, database.Count());
    }

    [Test]
    public void RemoveMethodShouldThrowExceptionIfArrayIsEmpty()
    {
        var database = new Database();

        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }

    [Test]
    public void RemoveSingleElementOfCollection()
    {
        var database = new Database(new int[] { 1, 2, 3, 4, 5 });

        database.Remove();

        Assert.AreEqual(4, database.Count());
    }

    [Test]
    public void RemoveShouldRemoveElementOfLastIndex()
    {
        var database = new Database(new int[] { 1, 2, 3, 4, 5 });

        database.Remove();
        database.Remove();

        CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, database.Fetch().ToArray());
    }

    [Test]
    public void RemoveManyElementOfCollection()
    {
        var database = new Database(new int[] { 1, 2, 3, 4, 5 });

        database.Remove();
        database.Remove();
        database.Remove();

        Assert.AreEqual(2, database.Count());
    }

    [Test]
    public void CheckIfAddedElementAreLastInDatabaseCollection()
    {
        var database = new Database(new int[] { 1, 2 });

        database.Add(3);
        database.Add(4);

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, database.Fetch());
    }
}
