// detail: https://atcoder.jp/contests/arc110/submissions/18590552
#include <bits/stdc++.h>
using namespace std;
using ll = long long;
#define var auto

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

const ll MOD = (int)(1e9 + 7);

constexpr ll factorial(int n){
  ll res = 1;
  for (int i = 1; i <= n; i++){
    res *= i;
    res %= MOD;
  }
  return res;
}

int main(){
  cin.tie(nullptr);
  ios::sync_with_stdio(false);
  int n, m;
  cin >> n >> m;
  vector<int> a(n);
  int sum = 0;
  for (int i = 0; i < n; i++){
    cin >> a[i];
    sum += a[i];
  }
  using M = Mint<int>;
  M res = 1;
  for (int i = 1, j = n + m; i <= sum + n; i++, j--){
    res *= j;
    res /= i;
  } 
  cout << res << endl;
  return 0;
}
