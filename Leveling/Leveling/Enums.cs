using System;
using Xunit.Abstractions;

namespace Leveling
{
    public class Enums
    {
        public void Move()
        {
            //here is an example where you would use math of the actual enums
            var xDirection = 0;
            //if (right arrow key pressed)
                xDirection += (int)HorizontalDirection.Right;
            //if (left arrow key pressed)
                xDirection += (int) HorizontalDirection.Left;

        }
    }

    //you only want to use enums hen there is a finite possible combinations of something, but they add much clarity
    public enum HorizontalDirection
    {
        //if you do not specify the numbers associated with each enum they are automatically assigned
        //you may not assign the same number to 2 different vlaues in the same enum
        //The first value in an enum list is the defualt value as null is not valid for an enum
        None = 0,
        //sometimes it is useful to assign values to perform math operations on them
        Right = 1,
        Left = -1
    }
}
