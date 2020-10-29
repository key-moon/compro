// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1322/judge/4951964/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

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
ostream& operator<<(ostream &os,Mint<T, MOD> m){os<<(m.v + m.mod) % m.mod;return os;}

using M = Mint<int, 2011>;

vector<string> s;
int h, w;

M parse(int, int, int, int);

void fit(int& ys, int& xs, int& yt, int& xt){
  while (true){
    bool flg = false;
    for (int i = ys; i <= yt; i++){
      if (s[i][xs] != '.'){
        flg = true;
        break;
      }
    }
    if (flg) break;
    xs++;
  }
  while (true){
    bool flg = false;
    for (int i = ys; i <= yt; i++){
      if (s[i][xt] != '.'){
        flg = true;
        break;
      }
    }
    if (flg) break;
    xt--;
  }
  while (true){
    bool flg = false;
    for (int i = xs; i <= xt; i++){
      if (s[ys][i] != '.'){
        flg = true;
        break;
      }
    }
    if (flg) break;
    ys++;
  }
  while (true){
    bool flg = false;
    for (int i = xs; i <= xt; i++){
      if (s[yt][i] != '.'){
        flg = true;
        break;
      }
    }
    if (flg) break;
    yt--;
  }
  assert(ys <= yt && xs <= xt);
}

M parsefactor(int ys, int yt, int basey, int& x){
  int sign = 1;
  //- の処理を忘れずに
  while (s[basey][x] == '-' && s[basey][x + 1] == '.'){
    sign *= -1;
    x += 2;
  }
  M res;
  //frac
  if (s[basey][x] == '-'){
    int xs = x;
    int xt;
    while (s[basey][x] == '-'){
      xt = x;
      x++;
    }
    var num = parse(ys, xs, basey - 1, xt);
    var den = parse(basey + 1, xs, yt, xt);
    res = num / den;
  }
  //primary
  else{
    if (s[basey][x] == '('){
      int xs = x + 1;
      int xt;
      int depth = 1;
      while (depth != 0){
        xt = x;
        x++;
        if (s[basey][x] == '(') depth++;
        if (s[basey][x] == ')') depth--;
      }
      assert(s[basey][x] == ')');
      x++;
      res = parse(ys, xs, yt, xt);
    }
    else{
      res = s[basey][x] - '0';
      x++;
    }
    //pow
    int power = s[basey - 1][x] - '0';
    if (0 <= power && power <= 9){
      x++;
      res = res.pow(power);
    }
  }
  return res * M(sign);
}

M parse(int ys, int xs, int yt, int xt){
  fit(ys, xs, yt, xt);

  int basey = -1;
  for (int i = ys; i <= yt; i++){
    if (s[i][xs] != '.'){
      basey = i;
      break;
    }
  }
  int curx = xs;
  vector<M> nums{};
  vector<char> ops{};
  while (1){
    M factor = parsefactor(ys, yt, basey, curx);
    if (ops.size() != 0 && ops.back() == '*'){
      nums.back() *= factor;
      ops.pop_back();
    }
    else{
      nums.push_back(factor);
    }
    curx++; // ? -> .
    if (curx <= xt){
      char op = s[basey][curx];
      curx++; // op -> .
      curx++; // . -> ?
      assert(op == '+' || op == '-' || op == '*');
      ops.push_back(op);
    }
    else{
      break;
    }
  }
  M res = nums[0];
  for (int i = 1; i < (int)nums.size(); i++){
    var op = ops[i - 1];
    if (op == '+'){
      res += nums[i];
      continue;
    }
    if (op == '-'){
      res -= nums[i];
      continue;
    }
    assert(false);
  }
  return res;
}

signed main() {
  int n;
  cin >> n;
  if (n == 0) return 0;
  h = 1 + n + 1;
  s = vector<string>(h);
  for (int i = 1; i <= n; i++){
    cin >> s[i];
    s[i] = '.' + s[i] + '.';
  }
  w = (int)s[1].size();
  s[0] = s[n + 1] = string(w, '.');
  cout << parse(0, 0, h - 1, w - 1) << endl;
  main();
}

