using Collections;
using System;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
        [Test]
        [Timeout(1000)]
        public void Test_Collection_1Million_Items()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }
        
        [Test]
        public void Test_Collection_Add()
        {
            //Arrenge 
            var coll = new Collection<string>("Ivan", "Peter");

            // Act
            coll.Add("Gosho");

            // Assert
            Assert.AreEqual(coll.ToString(), "[Ivan, Peter, Gosho]");
        }

        [Test]
        public void Test_Collection_Add_Range()
        {
            // Arrange
            var coll = new Collection<int>();

            // Act
            coll.Add(5);
            coll.Add(6);

            // Assert
            Assert.That(coll.ToString(), Is.EqualTo("[5, 6]"));
        }

        [Test]
        public void Test_Collection_Add_Range_With_Grow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_Add_Range_With_Grow_()
        {
            var collection = new Collection<int>();
            collection.AddRange(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Assert.AreEqual(collection.ToString(), "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]");
            Assert.That("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]", Is.EqualTo(collection.ToString()));
            Assert.AreEqual(collection.Count, 10, "Check for count");
            Assert.AreEqual(collection.Capacity, 16);

        }

        [Test]
        public void Test_Collection_Add_With_Grow()
        {
            var collection = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            collection.Add(5);
            collection.Add(5);
            Assert.AreEqual(collection.ToString(), "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 5, 5]");
            Assert.That("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 5, 5]", Is.EqualTo(collection.ToString()));
            Assert.AreEqual(collection.Count, 12, "Check for count");
            Assert.AreEqual(collection.Capacity, 20);
        }

        [Test]
        public void Test_Collection_Clear()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 7, 8, 9);
            // Act
            num.Clear();
            // Assert
            Assert.AreEqual(num.ToString(), "[]");
        }

        [Test]
        public void Test_Collection_Constructor_Multiple_Items()
        {
            //Arrenge & Act
            var coll = new Collection<int>(5, 6);

            // Assert
            Assert.AreEqual(coll.ToString(), "[5, 6]");
        }

        [Test]
        public void Test_Collection_Constructor_Single_Item()
        {
            //Arrenge & Act
            var coll = new Collection<int>(5);

            // Assert
            Assert.AreEqual(coll.ToString(), "[5]");
        }

        [Test]
        public void Test_Collection_Count_And_Capacity()
        {
            //Arrenge & Act
            var coll = new Collection<int>(5, 6);

            // Assert
            Assert.AreEqual(coll.Count, 2, "Check for Count");
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_Empty_Constructor()
        {
            //Arrenge & Act
            var coll = new Collection<int>();

            // Assert
            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collection_Exchange_First_Last_Int()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 7, 8);
            // Act
            num.Exchange(0, num.Count - 1);
            // Assert
            Assert.AreEqual(num.ToString(), "[8, 6, 7, 5]");
        }

        [Test]
        public void Test_Collection_Exchange_Invalid_Indexes_Int()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 7, 8);
            // Act & // Assert
            Assert.That(() => { num.Exchange(-1, 4); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_Exchange_Middle_Int()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 66, 7, 8, 88, 9);
            // Act
            num.Exchange(2, 5);
            // Assert
            Assert.AreEqual(num.ToString(), "[5, 6, 88, 7, 8, 66, 9]");
        }

        [Test]
        public void Test_Collection_Get_By_Index_Str()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");
            // Act
            var item0 = names[0];
            var item1 = names[1];
            // Assert
            Assert.That(item0, Is.EqualTo("Peter"));
            Assert.That(item1, Is.EqualTo("Maria"));
        }

        [Test]
        public void Test_Collection_Get_By_Index_Int()
        {
            //Arrenge 
            var coll = new Collection<int>(5, 6, 7);

            // Act
            var item = coll[1];

            // Assert
            Assert.That(item.ToString(), Is.EqualTo("6"));
        }

        [Test]
        public void Test_Collection_Get_By_Invalid_Index()
        {
            var names = new Collection<string>("Bob", "Joe");
            Assert.That(() => { var name = names[-1]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe]"));
        }

        [Test]
        public void Test_Collection_Get_By_Invalid_Index_2()
        {
            //Arrenge 
            var coll = new Collection<string>("Ivan", "Peter");

            // Assert
            Assert.That(() => { var item = coll[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            // проверява след последния индех, грешката.
            // Ако напишем coll[1] вместо 2, ще ни каже че вече съществува такъв
        }

        [Test]
        public void Test_Collection_Insert_At_End_Int()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 7, 8, 9);
            // Act
            num.InsertAt(num.Count, 10);
            // Assert
            Assert.AreEqual(num.ToString(), "[5, 6, 7, 8, 9, 10]");
        }

        [Test]
        public void Test_Collection_InsertAt_Invalid_Index_Min_Int()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 7);

            // Act & Assert
            Assert.That(() => { num.Exchange(-1, 2); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_InsertAt_Invalid_Index_Max_Input()
        {
            // Arrange
            var collection = new Collection<int>(5, 6, 7);
            // Act & Assert
            Assert.That(() => { collection.InsertAt(4, 9); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_InsertAt_Middle_Input()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 7, 8, 9);
            // Act
            num.InsertAt(2, 66);
            num.InsertAt(5, 88);
            // Assert
            Assert.AreEqual(num.ToString(), "[5, 6, 66, 7, 8, 88, 9]");
        }

        [Test]
        public void Test_Collection_InsertAt_Start_Int()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 7, 8, 9);
            // Act
            num.InsertAt(0, 4);
            // Assert
            Assert.AreEqual(num.ToString(), "[4, 5, 6, 7, 8, 9]");
        }

        [Test]
        public void Test_Collection_InsertAt_Grow()
        {
            // Arrange
            var num = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            // Act
            num.InsertAt(0, 5);
            // Assert
            Assert.AreEqual(num.ToString(), "[5, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]");
            Assert.That("[5, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]", Is.EqualTo(num.ToString()));
            Assert.AreEqual(num.Count, 11, "Check for count");
            Assert.AreEqual(num.Capacity, 20);
        }

        [Test]
        public void Test_Collection_InsertAt_With_Grow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();

            for (int i = 0; i < newNums.Length; i++)
            {
                nums.InsertAt(i, newNums[i]);
            }

            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_Remove_All_String()
        {
            //Arrange
            var myColl = new Collection<string>("Green", "Red");
            var expected = "[]";

            //Act
            myColl.RemoveAt(0);
            myColl.RemoveAt(0);

            //Assert
            Assert.That(expected, Is.EqualTo(myColl.ToString()));
        }

        [Test]
        public void Test_Collection_Remove_At_End()
        {
            //Arrange
            var myColl = new Collection<string>("Green", "Red", "Blue");
            var expected = "[]";

            //Act
            myColl.RemoveAt(0);

            //Assert
            Assert.AreEqual(myColl.ToString(), "[Red, Blue]");
        }

        [Test]
        public void Test_Collection_Remove_At_Invalid_Indexes()
        {
            //Arrange
            var myColl = new Collection<int>(5, 6, 7);
            var expected = "[]";

            // Act & Assert
            Assert.That(() => { myColl.RemoveAt(3); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_Remove_At_Middle_Str()
        {
            //Arrange
            var myColl = new Collection<string>("Green", "Red", "Blue");
            var expected = "[]";

            //Act
            myColl.RemoveAt(1);

            //Assert
            Assert.AreEqual(myColl.ToString(), "[Green, Blue]");
        }

        [Test]
        public void Test_Collection_Remove_At_Middle_Int()
        {
            // Arrange
            var num = new Collection<int>(5, 6, 88, 7, 8, 66, 9);
            // Act
            num.RemoveAt(2);
            num.RemoveAt(4);
            // Assert
            Assert.AreEqual(num.ToString(), "[5, 6, 7, 8, 9]");
        }

        [Test]
        public void Test_Collection_RemoveAt_Start()
        {
            //Arrange
            var myColl = new Collection<string>("Green", "Red", "Blue");
            var expected = "[]";

            //Act
            myColl.RemoveAt(myColl.Count - 1);

            //Assert
            Assert.AreEqual(myColl.ToString(), "[Green, Red]");
        }

        [Test]
        public void Test_Collection_Set_By_Index()
        {
            //Arrenge 
            var coll = new Collection<int>(2, 3, 4);

            // Act
            coll[1] = 33;

            // Assert
            Assert.That(coll.ToString(), Is.EqualTo("[2, 33, 4]"));
        }

        [Test]
        public void Test_Collection_Set_By_Invalid_Index()
        {
            var collection = new Collection<int>(5, 6, 7);
            Assert.That(() => { collection[3] = 66; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_ToString_Nested_Collections()
        {
            //arrange
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();

            //act
            var nested = new Collection<object>(names, nums, dates);

            //assert
            string nestedToString = nested.ToString();
            Assert.That(nestedToString,
              Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));

        }

        [Test]
        public void Test_Collection_To_String_Empty()
        {
            //arrange
            var myColl = new Collection<int>();

            var expected = "[]";
            var actual = myColl.ToString();

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_To_String_Multiple()
        {
            //arrange
            var myColl = new Collection<int>(55, 22);

            var expected = "[55, 22]";
            var actual = myColl.ToString();

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test_Collection_To_String_Single()
        {
            //arrange
            var myColl = new Collection<int>(55);

            var expected = "[55]";
            var actual = myColl.ToString();

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

    }
}