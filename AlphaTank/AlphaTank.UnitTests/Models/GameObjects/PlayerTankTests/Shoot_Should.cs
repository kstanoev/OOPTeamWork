﻿using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.Models.GameObjects.PlayerTankTests
{
    [TestClass]
    public class Shoot_Should
    {
        private Mock<IMap> mapMock;

        [TestInitialize]
        public void Initialize()
        {
            mapMock = new Mock<IMap>();

            mapMock.Setup(map => map.GetLength(1)).Returns(10);
            mapMock.Setup(map => map.GetLength(0)).Returns(10);
        }

        [TestMethod]
        public void Return_Correct_Value_When_Direction_IsUp()
        {
            //arrange
            var row = 2;
            var col = 3;
            var direction = Direction.Up;

            var envFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            var expectedShell = new Mock<IShell>();

            envFactoryStub.Setup(f => f.CreateShell(row - 1, col, mapMock.Object, direction, envFactoryStub.Object, collisionStub.Object)).Returns(expectedShell.Object);

            var playerTank = new PlayerTank(row, col, direction, mapMock.Object, envFactoryStub.Object, collisionStub.Object);

            //act
            var actualShell = playerTank.Shoot();

            //assert
            Assert.AreSame(expectedShell.Object, actualShell);
        }

        [TestMethod]
        public void Return_Correct_Value_When_Direction_IsRight()
        {
            //arrange
            var row = 2;
            var col = 3;
            var direction = Direction.Right;

            var envFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            var expectedShell = new Mock<IShell>();

            envFactoryStub.Setup(f => f.CreateShell(row, col + 1, mapMock.Object, direction, envFactoryStub.Object, collisionStub.Object)).Returns(expectedShell.Object);

            var playerTank = new PlayerTank(row, col, direction, mapMock.Object, envFactoryStub.Object, collisionStub.Object);

            //act
            var actualShell = playerTank.Shoot();

            //assert
            Assert.AreSame(expectedShell.Object, actualShell);
        }

        [TestMethod]
        public void Return_Correct_Value_When_Direction_IsDown()
        {
            //arrange
            var row = 2;
            var col = 3;
            var direction = Direction.Down;

            var envFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            var expectedShell = new Mock<IShell>();

            envFactoryStub.Setup(f => f.CreateShell(row + 1, col, mapMock.Object, direction, envFactoryStub.Object, collisionStub.Object)).Returns(expectedShell.Object);

            var playerTank = new PlayerTank(row, col, direction, mapMock.Object, envFactoryStub.Object, collisionStub.Object);

            //act
            var actualShell = playerTank.Shoot();

            //assert
            Assert.AreSame(expectedShell.Object, actualShell);
        }

        [TestMethod]
        public void Return_Correct_Value_When_Direction_IsLeft()
        {
            //arrange
            var row = 2;
            var col = 3;
            var direction = Direction.Left;

            var envFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            var expectedShell = new Mock<IShell>();

            envFactoryStub.Setup(f => f.CreateShell(row, col - 1, mapMock.Object, direction, envFactoryStub.Object, collisionStub.Object)).Returns(expectedShell.Object);

            var playerTank = new PlayerTank(row, col, direction, mapMock.Object, envFactoryStub.Object, collisionStub.Object);

            //act
            var actualShell = playerTank.Shoot();

            //assert
            Assert.AreSame(expectedShell.Object, actualShell);
        }
    }
}
