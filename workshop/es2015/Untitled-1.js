// Создаётся объект promise
let promiseCreateor = () => new Promise((resolve, reject) => {
  setTimeout(() => {
    // переведёт промис в состояние fulfilled с результатом "result"
    resolve("result");
  }, 1000);
});

let promiseCreator = [promiseCreateor(), promiseCreateor(), promiseCreateor()]