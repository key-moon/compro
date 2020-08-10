# detail: https://atcoder.jp/contests/agc047/submissions/15803786
p=print
r=range
def a(i,j,k,l=0):p("+<"[l],i,j,k)
def b(i):a(i,i,i+1)
def d(x,i):
	a(x,3,x)
	for t in r(30):b(p:=i+t+30);a(q:=p+1,3,q);[*map(b,r(q,v:=i+60))];a(v,x,i+t,1);b(p);a(q,i+t,q)
p(3934)
a(0,1,3)
a(2,3,3,1)
d(0,9)
d(1,50)
for t in r(60):a(2,2,2);[t-31<s<30!=(a(8+t-s,50+s,5),a(3,5,6,1),a(2,6,2))for s in r(t)]