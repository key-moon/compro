// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_A/judge/3374155/C++14
#include<bits/stdc++.h>
using namespace std;
struct uf{
vector<int> v;
uf(int n):v(n){
iota(v.begin(),v.end(),0);
}
int find(int x) {return v[x] == x ? x : v[x]=find(v[x]);}
void unite(int x,int y) {v[find(x)]=find(y);}
};
struct rmq{
  vector<int> v;
  int size;
  rmq(int n){
    size=1;
    while(size<n)size<<=1;
    v=vector<int>(size*2,2147483647);
  }
  void update(int i,int x){
    v[size+i]=x;
    _update((size+i)/2,x);
    //for(auto&& item : v) cout<<item<<" ";
    //cout<<endl;
  }
  void _update(int i,int x){
    if(i==0)return;
    v[i]=min(v[i*2],v[i*2+1]);
    _update(i/2,x);
  }
  int query(int l,int r,int i,int x,int y){
    if(y<l||r<x) return 2147483647;
    if(l<=x&&y<=r) return v[i];
    
    return min(query(l,r,i*2,x,(x+y)/2),
               query(l,r,i*2+1,(x+y)/2+1,y));
  }
};
int main(){
  int n,q;
  cin>>n>>q;
  rmq r(n);
  for(int i=0;i<q;i++){
    int a,b,c;
    cin>>a>>b>>c;
    if(a==0)r.update(b,c);
    else cout<<r.query(b,c,1,0,r.size-1)<<endl;
  }
}
