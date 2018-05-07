describe("Null vs Undefined", () => {
    describe("When asking for a property not present on an object", () => {
        it("Should be undefined", () => {
            expect({}.nonExistentProperty).toEqual(undefined);
        });
    });
    describe("When asking about type type", () => {
        it("Should be object for null", () => {
            expect(typeof(null)).toEqual('object');
        });
        it("Should be undefined for undefined", () => {
            expect(typeof(undefined)).toEqual('undefined');
        });
    });
    describe("When using type coercion", () => {
        it("Should be 0 for null as a number", () => {
            expect(3 + null).toEqual(3);
        });
        it("Should be NaN for undefined as a number", () => {
            expect(3 + undefined).toEqual(NaN);
        });
    });
});
//JS unlike other languages never initializes things with null it always goes to undefined, so when you see null you know some explicitly set that to null at some point