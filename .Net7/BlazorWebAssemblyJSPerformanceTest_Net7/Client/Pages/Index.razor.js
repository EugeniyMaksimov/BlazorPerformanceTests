export function calculate() {
    let result = 0;
    for(let i = 0; i < 1_000_000_000; i++) {
        result += i * 0.5 + i / 0.3;
    }
    return result;
}