# detail: https://atcoder.jp/contests/agc047/submissions/15809624
P,L="+<"
p=print
r=range
p(6484,P,0,1,3,L,2,3,3,P,0,3,0,P,1,3,1)
for x in 0,1:[p(P,v:=x+4,v,v,P,v,3,6,*[P,6,6,6]*(29-t),L,6,x,T:=x*60+9+t,P,v,T,v)for t in r(30)]
for t in r(60):p(P,2,2,2);[p(P,8+t-s,69+s,5,L,3,5,6,P,2,6,2)for s in r(t)]