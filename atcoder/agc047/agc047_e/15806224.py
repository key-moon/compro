# detail: https://atcoder.jp/contests/agc047/submissions/15806224
p=print
r=range
def a(i,j,k,l=0):p("+<"[l],i,j,k)
def b(i):a(i,i,i)
def d(x):
	a(x,3,x)
	for t in r(30):b(x+4);a(x+4,3,6),*map(b,[6]*(29-t));a(6,x,T:=x*60+35+t,1);a(x+4,T,x+4)
p(3874)
a(0,1,3)
a(2,3,3,1)
d(0)
d(1)
for t in r(60):b(2);[t-31<s<30!=(a(34+t-s,95+s,5),a(3,5,6,1),a(2,6,2))for s in r(t)]