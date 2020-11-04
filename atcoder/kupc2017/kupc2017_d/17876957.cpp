// detail: https://atcoder.jp/contests/kupc2017/submissions/17876957
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

//BEGIN CUT HERE
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
//END CUT HERE

using M = Mint<int>;

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n;
  cin >> n;
  if (n <= 2){
    cout << 1 << " " << 1 << endl;
    return 0;
  }
  if (n <= 4) {
    int res = 0;
    int N = n;
    vector<vector<int>> st(N, vector<int>(N));
    for (int b = 0; b < (1 << N * N); b++){
      for (int i = 0; i < N; i++){
        for (int j = 0; j < N; j++){
          var id = i * N + j;
          st[i][j] = b >> id & 1;
        }
      }
      for (int i = 0; i < N; i++){
        for (int j = 0; j < N - 2; j++){
          int sum1 = 0;
          int sum2 = 0;
          for (int k = 0; k < 3; k++){
            sum1 += st[i][j + k];
            sum2 += st[j + k][i];
          }
          if (sum1 == 0 || sum1 == 3) goto end1;
          if (sum2 == 0 || sum2 == 3) goto end1;
        }
        int sum1 = 0;
        int sum2 = 0;
      }
      {
        for (int i = 0; i < N - 2; i++){
          for (int j = 0; j < N - 2; j++){
            int sum1 = 0, sum2 = 0;
            for (int k = 0; k < 3; k++){
              sum1 += st[i + k][j + k];
              sum2 += st[i + k][N - 1 - (j + k)];
            }
            if (sum1 == 0 || sum1 == 3) goto end1;
            if (sum2 == 0 || sum2 == 3) goto end1;
          }
        }
      }
      res++;
      end1:;
    }
    cout << "2 " << res << endl;
    return 0;
  }
  cout << "2 8" << endl;
  return 0;
}
