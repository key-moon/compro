# detail: https://atcoder.jp/contests/agc047/submissions/15807331
r=range
def a(i,j,k,l="+"):print(l,i,j,k)
print(6484)
a(0,1,3)
a(2,3,3,L:="<")
for x in 0,1:
	a(x,3,x)
	for t in r(30):a(v:=x+4,v,v);a(v,3,6),exec('a(6,6,6);'*(29-t));a(6,x,T:=x*60+9+t,L);a(v,T,v)
for t in r(60):a(2,2,2);[(a(8+t-s,69+s,5),a(3,5,6,L),a(2,6,2))for s in r(t)]