# detail: https://atcoder.jp/contests/agc047/submissions/15805113
p=print
r=range
c=0
def a(i,j,k,l=0):
	global c
	p("+<"[l],i,j,k)
	c = c + 1
def b(i):a(i,i,i+1)
def d(x,i):
	a(x,3,x)
	for t in r(i,i+30):
		b(p:=t+1)
		a(q:=p+1,3,q)
		[*map(b,r(q,i+31))]
		a(i+31,x,t,1)
		b(p)
		a(q,t,q)
p(3934)
a(0,1,3)
a(2,3,3,1)
d(0,9)
d(1,50)
for t in r(60):a(2,2,2);[t-31<s<30!=(a(8+t-s,50+s,5),a(3,5,6,1),a(2,6,2))for s in r(t)]