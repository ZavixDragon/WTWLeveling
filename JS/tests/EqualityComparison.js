//There is '==' and '==='
//the first one will coerce the types to matching types before equality comparison
//the second one will straight up say its false if they are different types
describe("Equality Comparison", () => {
    describe("When using '===' for equality comparisons", () => {
        it("Should not coerce the types", () => {
            expect(0 === null).toBeFalsy();
        });
        it("Should be equal when they are the exact same object", () => {
            let obj = {};
            expect(obj === obj).toBeTruthy();
        });
        it("Should not be equal when they are different object", () => {
            expect({} === {}).toBeFalsy();
        });
    });
    describe("When using '==' for equality comparisons", () => {
        //We will get into depth about type coercion later for now you just need to be aware it does type coercion here
        it("Should coerce types before comparison", () => {
            expect(0 == "0").toBeTruthy();
        });
    });
});
