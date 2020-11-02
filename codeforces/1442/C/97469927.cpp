// detail: https://codeforces.com/contest/1442/submission/97469927
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

//BEGIN CUT HERE
template<typename T>
struct Dijkstra{
  struct Edge{
    int to;
    T cost;
    Edge(int to,T cost):to(to),cost(cost){}
    bool operator<(const Edge &o)const{return cost>o.cost;}
  };

  vector< vector<Edge> > G;
  vector<T> ds;
  vector<int> bs;
  Dijkstra(int n):G(n){}

  void add_edge(int u,int v,T c){
    G[u].emplace_back(v,c);
  }

  void build(int s){
    int n=G.size();
    ds.assign(n,numeric_limits<T>::max());
    bs.assign(n,-1);

    priority_queue<Edge> pq;
    ds[s]=0;
    pq.emplace(s,ds[s]);

    while(!pq.empty()){
      auto p=pq.top();pq.pop();
      int v=p.to;
      if(ds[v]<p.cost) continue;
      for(auto e:G[v]){
        if(ds[e.to]>ds[v]+e.cost){
          ds[e.to]=ds[v]+e.cost;
          bs[e.to]=v;
          pq.emplace(e.to,ds[e.to]);
        }
      }
    }
  }

  T operator[](int k){return ds[k];}

  vector<int> restore(int to){
    vector<int> res;
    if(bs[to]<0) return res;
    while(~to) res.emplace_back(to),to=bs[to];
    reverse(res.begin(),res.end());
    return res;
  }
};
//END CUT HERE

template<typename T, T MOD = 1000000007>
struct Mint{
  static constexpr T mod = MOD;
  T v;
  Mint():v(0){}
  Mint(signed v):v(v){}
  Mint(long long t){v=t%MOD;if(v<0) v+=MOD;}

  Mint pow(long long k){
    Mint res(1),tmp(v);
    while(k){
      if(k&1) res*=tmp;
      tmp*=tmp;
      k>>=1;
    }
    return res;
  }

  static Mint add_identity(){return Mint(0);}
  static Mint mul_identity(){return Mint(1);}

  Mint inv(){return pow(MOD-2);}

  Mint& operator+=(Mint a){v+=a.v;if(v>=MOD)v-=MOD;return *this;}
  Mint& operator-=(Mint a){v+=MOD-a.v;if(v>=MOD)v-=MOD;return *this;}
  Mint& operator*=(Mint a){v=1LL*v*a.v%MOD;return *this;}
  Mint& operator/=(Mint a){return (*this)*=a.inv();}

  Mint operator+(Mint a) const{return Mint(v)+=a;}
  Mint operator-(Mint a) const{return Mint(v)-=a;}
  Mint operator*(Mint a) const{return Mint(v)*=a;}
  Mint operator/(Mint a) const{return Mint(v)/=a;}

  Mint operator-() const{return v?Mint(MOD-v):Mint(v);}

  bool operator==(const Mint a)const{return v==a.v;}
  bool operator!=(const Mint a)const{return v!=a.v;}
  bool operator <(const Mint a)const{return v <a.v;}

  static Mint comb(long long n,int k){
    Mint num(1),dom(1);
    for(int i=0;i<k;i++){
      num*=Mint(n-i);
      dom*=Mint(i+1);
    }
    return num/dom;
  }
};
template<typename T, T MOD> constexpr T Mint<T, MOD>::mod;
template<typename T, T MOD>
ostream& operator<<(ostream &os,Mint<T, MOD> m){os<<m.v;return os;}


using D = Dijkstra<ll>;
using Edge = D::Edge;

using M = Mint<int, 998244353>;

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n, m;
  cin >> n >> m;
  vector<vector<Edge>> graph(n);
  const int LAYER = 20;
  Dijkstra<ll> d20(n * LAYER);
  Dijkstra<ll> d2(n * 2);
  ll INF = 1LL << 32;
  for (int i = 0; i < m; i++){
    int u, v;
    cin >> u >> v;
    u--, v--;
    graph[u].emplace_back(v, 1LL);
    for (int j = 0; j < LAYER; j++){
      int offset = n * j;
      int nxtoffset = n * (j + 1);
      if ((j % 2) == 0) {
        d20.add_edge(offset + u, offset + v, 1LL);
        if (j == LAYER - 1) continue;
        d20.add_edge(offset + v, nxtoffset + u, (1LL << j) + 1);
      }
      else {
        d20.add_edge(offset + v, offset + u, 1LL);
        if (j == LAYER - 1) continue;
        d20.add_edge(offset + u, nxtoffset + v, (1LL << j) + 1);
      } 
    }
    //graph2
    {
      d2.add_edge(u, v, 1LL);
      d2.add_edge(v, u + n, INF + 1);

      d2.add_edge(v + n, u + n, 1LL);
      d2.add_edge(u + n, v, INF + 1);
    }
  }
  d20.build(0);
  d2.build(0);
  var res = INT64_MAX;
  for (int i = 0; i < LAYER; i++){
    chmin(res, d20[n - 1 + i * n]);
  }
  var d2res = min(d2[n - 1], d2[n - 1 + n]);
  var flip = d2res / INF;
  var edgecost = d2res % INF;
  if (flip <= 25){
    ll totalcost = edgecost;
    ll curflipcost = 1;
    for (int i = 0; i < flip; i++){
      totalcost += curflipcost;
      curflipcost *= 2;
    }
    chmin(res, totalcost);
    cout << res << endl;
    return 0;
  }

  {
    M totalcost = edgecost;
    M curflipcost = 1;
    for (int i = 0; i < flip; i++){
      totalcost += curflipcost;
      curflipcost *= 2;
    }
    cout << totalcost << endl;
    return 0;
  }
  
  return 0;
}
