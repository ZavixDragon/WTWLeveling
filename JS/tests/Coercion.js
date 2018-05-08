describe("Coercion", () => {
    //What causes coercion?

    //There is explicit coercion
    it("Should convert number to boolean explicitly", () => {
        expect(Boolean(1)).toEqual(true);
    });
    it("Should convert string to number explicitly", () => {
        expect(Number("1")).toEqual(1);
    });
    it("Should convert null to string explicitly", () => {
        expect(String(null)).toEqual("null");
    });

    //Now there is only three kinds of coercion to Booleans String and Numbers
    //First up the implicit boolean converters
    it("Should implicitly convert to boolean when using '!' value", () => {
        expect(!"all non empty string are true").toEqual(false);
    });
    it("Should implicitly convert to boolen using the '?' operator", () => {
        expect(1 ? "true" : "false").toEqual("true");
    });
    it("Should implicitly convert when using the '||' operator", () => {
        if (0 || null)
            fail("The above statement should be false");
    });
    it("Should implicitly convert when using the '&&' operator", () => {
        if (0 && [])
            fail("The above statement should be false");
    });
    //You noticed that the above 2 statements look a little weirder than the rest of the tests they don't do an expect + equals
    //This is because for some silly reason the '||' and '&&' symbols will return the second value rather than its converted value
    it("Should give you second value over the boolean expression", () => {
        expect(true && 9).toEqual(9);
    });

    //Next up lets look at the implicit number converters
    //the comparison operators
    it("Should implicitly convert to numbers when comparing with '>'", () => {
        expect(true > null).toEqual(true);
    });
    it("Should implicitly convert to numbers when comparing with '<'", () => {
        expect("3" < ["9"]).toEqual(true);
    });
    it("Should implicitly convert to numbers when comparing with '>='", () => {
        expect(false >= null).toEqual(true);
    });
    it("Should implicitly convert to numbers when comparing with '<='", () => {
        expect(true <= "27").toEqual(true);
    });
    //the bitwise operators
    it("Should implicitly convert to numbers with '^' exclusive-or operator", () => {
        expect("0x100" ^ "0x110").toEqual(0x010);
    });
    it("Should implicitly convert to numbers with '|' inclusive-or operator", () => {
        expect("0x100" | "0x110").toEqual(0x110);
    });
    it("Should implicitly convert to numbers with '&' and operator", () => {
        expect("0x100" & "0x110").toEqual(0x100);
    });
    it("Should implicitly convert to numbers with '~' not operator", () => {
        expect(~["9"]).toEqual(-10);
    });
    it("Should implicitly convert to numbers with '>>' left shift", () => {
        expect("9" >> "1").toEqual(4);
    });
    it("Should implicitly convert to numbers with '<<' right shift", () => {
        expect("9" << "1").toEqual(18);
    });
    //the math operators
    it("Should implicitly convert to numbers with the '-' symbol", () => {
        expect("9" - true).toEqual(8);
    });
    it("Should implicitly convert to numbers with the '*' symbol", () => {
        expect(["3"] * "9").toEqual(27);
    });
    it("Should implicitly convert to numbers with the '/' symbol", () => {
        expect(null / "3").toEqual(0);
    });
    it("Should implicitly convert to numbers with the '%' symbol", () => {
        expect(["27"] % "5").toEqual(2);
    });
    //the '+' operator has some extra rules
    //but as long as no side is strings it will do a number check
    it("Should implicitly convert o numbers when using '+' with no strings attached or arrays as they are converted to strings first", () => {
        expect(null + true).toEqual(1);
    });
    //The other thing is there is the '+' that adds things and the '+' that tells something is positive
    //because of this you can force a number conversion
    it("Should implicitly convert string to number then add them with the double '+'", () => {
        expect(3 + + "6").toEqual(9);
    });
    it("Should implicitly convert string to number with '-' then add them", () => {
        expect(9 + - "6").toEqual(3);
    });
    //Now to show off the 2 cases that '+' does a string addition
    it("Should implicitly convert the number to string with '+' when one side is a string", () => {
        expect(3 + "3").toEqual("33");
    });
    it("Should implicitly convert the number to string as well as the array to string with '+' when one side is an array", () => {
        expect(3 + ["3"]).toEqual("33");
    });

    //lastly is '==', in general it tries to coerce non matching types to numbers for comparison, but there are a lot of exceptions
    it("Should implicitly convert to numbers with '=='", () => {
        expect("1" == true).toEqual(true);
    });
    //First exception is when you add an array and string it compares them as strings
    it("Should first convert array to string and then compare the 2 sides as strings with '=='", () => {
        expect("2,3" == ["2", "3"]).toEqual(true);
    });
    //Second exception is that null will not be coerced so it is only equal to null and undefined
    it("Should not match, null and 0", () => {
        expect(0 == null).toEqual(false);
    });
    it("Should match when comparing null and undefined", () => {
        expect(null == undefined).toEqual(true);
    });
    //Third exception is that NaN does not equal anything including itself
    it("Should not match when comparing NaN to itself", () => {
        let nan = NaN;
        expect(nan == nan).toEqual(false);
    });

    //Now that we know what tries to do coercion lets show how certain types like to be coerced
    //you already can read how things convert to booleans in TruthyAndFalsy.js so we are going to skip that nonsense

    //Symbols have bunch of oddities
    it("Should throw an error when coercing Symbol to number", () => {
        expect(() => Number(Symbol("3"))).toThrow();
    });
    it("Should throw an error when implicitly coercing Symbol to string", () => {
        expect(() => "" + Symbol("here we go!")).toThrow();
    });
    it("Should convert with toString when explicitly coercing Symbol to string", () => {
        expect(String(Symbol("here we go!"))).toEqual("Symbol(here we go!)");
    });

    //Booleans are pretty simple
    it("Should convert true to 'true' when doing a string conversion", () => {
        expect(String(true)).toEqual("true");
    });
    it("Should convert true to 1 with number conversion", () => {
        expect(Number(true)).toEqual(1);
    });
    it("Should convert false to 0 with number conversion", () => {
        expect(Number(false)).toEqual(0);
    });

    //Strings are pretty basic
    it("Should convert string to NaN if they are not formatted as a number", () => {
         expect(Number("not a number")).toEqual(NaN);
    });
    it("Should convert string to proper number when formatted correctly", () => {
        expect(Number("9.3")).toEqual(9.3);
    });
    it("Should convert string to number even when there are spaces to trim", () => {
        expect(Number(" 2 ")).toEqual(2);
    });

    //Null is easy
    it("Should convert null to 'null' with string conversion", () => {
        expect(String(null)).toEqual("null");
    });
    it("Should convert null to 0 with number conversion", () => {
        expect(Number(null)).toEqual(0);
    });

    //Now to define Undefined
    it("Should convert undefined to 'undefined' with string conversion", () => {
        expect(String(undefined)).toEqual("undefined");
    });
    it("Should convert undefined to NaN with number conversion", () => {
        expect(Number(undefined)).toEqual(NaN);
    });

    //Numbers work exactly as you expect them to
    it("Should convert number to number in quotes with string conversion", () => {
        expect(String(9)).toEqual("9");
    });

    //Arrays have a slightly interesting quirk,
    //they cannot directly convert to a number so they first convert to string then to number
    //because of this quirk we only need to know how it converts to string to know how it converts to number
    it("Should convert empty array to empty string", () => {
        expect(String([])).toEqual("");
    });
    it("Should convert single element array to the elements string value", () => {
        expect(String([ true ])).toEqual("true");
    });
    it("Should add commas between each element the array converts", () => {
        expect(String([ 9, true ])).toEqual("9,true");
    });
    //there is one interesting thing that it won't write undefined or null
    it("Should ignore null and undfined in array with conversion", () => {
        expect(String([ 3, null, undefined, 3 ])).toEqual("3,,,3");
    });

    //Objects are also simple
    it("Should convert to generic object string with string conversion", () => {
        expect(String({})).toEqual("[object Object]");
    });
    it("Should convert object to NaN with numeric conversion", () => {
        expect(Number({})).toEqual(NaN);
    });

    //There are two ways to override how an object converts
    //the simplest way is to override these methods
    function OverridenConversionCalls() {
        this.valueOf = () => {
            return 9;
        };

        this.toString = () => {
            return "hooray";
        }
    }

    it("Should use valueOf for number conversion", () => {
        expect(Number(new OverridenConversionCalls())).toEqual(9);
    });
    it("Should use toString for string conversion", () => {
        expect(String(new OverridenConversionCalls())).toEqual("hooray");
    });

    //the second way is you can in ES6 implement this
    class ReplacesInternalToPrimitive {
        [Symbol.toPrimitive](hint) {
            return "9";
        }
    }

    it("Should use to primitive underneath the surface for conversion", () => {
        expect(String(new ReplacesInternalToPrimitive())).toEqual("9");
        expect(Number(new ReplacesInternalToPrimitive())).toEqual(9);
    });
});