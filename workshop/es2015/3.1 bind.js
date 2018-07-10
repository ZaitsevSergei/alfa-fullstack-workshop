// var a = function(b, c) {
//   return b + c;
// };

// const c = (b, c) => b + c;

var user = {
  firstName: "Вася",
  sayHi: function() {
    console.log(this.firstName);
  }
};

function (context) {
  return function () {
    this.call(context);
  }
}

var myBind = (context) => _ => this.call(funct);
user.sayHi.myBind = f;


// TODO
setTimeout(user.sayHi.myBind(user), 1000);
