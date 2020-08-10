# detail: https://atcoder.jp/contests/agc047/submissions/15802230
n=97
p=print
r=range
def a(i,j,k,l=0):p("+<"[l],i,j,k)
def b(i):a(i,i,i+1)
def d(x,i,j):
	for t in r(30):b(p:=j+t-1);a(j+t,n,j+t);[*map(b,r(j+t,j+29))];a(j+29,x,i+t,1);b(p);a(j+t,i+t,j+t)
p(3933)
a(0,1,n)
a(2,n,n,1)
a(0,n,3)
a(1,n,4)
d(3,5,36)
d(4,36,67)
for t in r(59):a(2,2,2);[(a(5+t-s,36+s,98),a(n,98,99,1),a(2,99,2))for s in r(t+1)if t-30<s<30]