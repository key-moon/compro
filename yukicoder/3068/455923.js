// detail: https://yukicoder.me/submissions/455923
p=process
u='ut'
o={}
o['inp'+u]=p.stdin
o['outp'+u]=p.stdout
require('rea'+'dline')['createI'+'nterface'](o).on('line',s=>{
global["ev"+"al"](`b=false;s='${s}';fo`+"r(var i=0;i<s.length;i++)i"+"f(b=new Set(s.slice(i,i+9)).size==9)break;console.log(b?'Yes':'No');")
});
