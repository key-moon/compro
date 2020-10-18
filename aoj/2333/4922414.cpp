// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2333/judge/4922414/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

//BEGIN CUT HERE
template<typename T,T MOD = 1000000007>
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
template<typename T,T MOD> constexpr T Mint<T, MOD>::mod;
template<typename T,T MOD>
ostream& operator<<(ostream &os,Mint<T, MOD> m){os<<m.v;return os;}
//END CUT HERE

using M = Mint<int>;

int main(){
  int n, w;
  cin >> n >> w;
  vector<M> ps(w + 1);
  vector<int> ws(n);
  for (int i = 0; i < n; i++){
    cin >> ws[i];
  }

  M res;
  {  
    ps[0] = 1;
    for (int i = 0; i < n; i++){
      int a = ws[i];
      for (int j = w; j >= a; j--){
        ps[j] += ps[j - a];
      }
    }
    res = accumulate(ps.begin(), ps.end(), M(0));
  }

  sort(ws.begin(), ws.end());
  for (int notuse = 0; notuse < n; notuse++){
    int sum = 0;
    for (int i = 0; i < notuse; i++){
      sum += ws[i];
    }
    ps = vector<M>(w + 1);
    if (w <= sum) continue;
    ps[sum] = 1;
    for (int i = notuse + 1; i < n; i++){
      for (int j = w; j >= ws[i]; j--){
        ps[j] += ps[j - ws[i]];
      }
    }
    for (int i = 0; i + ws[notuse] <= w; i++){
      res -= ps[i];
    }
  }
  cout << res << endl;
}

