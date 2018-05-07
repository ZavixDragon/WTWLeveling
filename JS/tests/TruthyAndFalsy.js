//Truthy and Falsy check more then just booleans they can check other types for truthiness
//This is most useful i think in check if something is null or undefined before use
describe("Truthy And Falsy", () => {
    //here is the specifics on numbers
    it("0 is falsy", () => {
        expect(0).toBeFalsy();
    });
    it("NaN is falsy", () => {
        expect(NaN).toBeFalsy();
    });
    it("Number above 0 is truthy", () => {
        expect(9).toBeTruthy();
    });
    it("Negative number is truthy", () => {
        expect(-3).toBeTruthy();
    });

    //obviously it handles straight booleans like you would expect
    it("false is falsy", () => {
        expect(false).toBeFalsy();
    });
    it("true is truthy", () => {
        expect(true).toBeTruthy();
    });

    //strings are also a very useful shorthand for checking empty
    it("empty string is falsy", () => {
        expect("").toBeFalsy();
    });
    //in my opinion i think its unfortunate it does not consider whitespace to be falsy
    it("whitespace string is truthy", () => {
        expect("   ").toBeTruthy();
    });
    it("normal string is truthy", () => {
        expect("bob").toBeTruthy();
    });

    //now the only falsy object is null
    it("null is falsy", () => {
        expect(null).toBeFalsy();
    });
    it("legit object is truthy", () => {
        expect({}).toBeTruthy();
    });

    it("undefined is falsy", () => {
        expect(undefined).toBeFalsy();
    });

    it("Symbol is truthy", () => {
        expect(Symbol()).toBeTruthy();
    });
});