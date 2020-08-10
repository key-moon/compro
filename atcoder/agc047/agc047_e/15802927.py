# detail: https://atcoder.jp/contests/agc047/submissions/15802927
p=print
r=range
def a(i,j,k,l=0):p("+<"[l],i,j,k)
def b(i):a(i,i,i+1)
def d(x,i):
	for t in r(30):b(p:=i+t+30);a(q:=p+1,n,q);[*map(b,r(q,i+60))];a(i+60,x,i+t,1);b(p);a(q,i+t,q)
p(n:=3933)
a(0,1,n)
a(2,n,n,1)
a(0,n,3)
a(1,n,4)
d(3,5)
d(4,36)
for t in r(59):a(2,2,2);[t-30<s<30!=(a(5+t-s,36+s,98),a(n,98,99,1),a(2,99,2))for s in r(t+1)]