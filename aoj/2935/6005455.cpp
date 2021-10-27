// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2935/judge/6005455/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

template<typename T>
struct Rint {
  static T mod;
  static void set_mod(T nmod) { mod = nmod; }

  T v;
  Rint() :v(0) {}
  Rint(signed v) :v(v) {}
  Rint(long long t) { v = t % mod; if (v < 0) v += mod; }

  Rint pow(long long k) {
    Rint res(1), tmp(v);
    while (k) {
      if (k & 1) res *= tmp;
      tmp *= tmp;
      k >>= 1;
    }
    return res;
  }

  static Rint add_identity() { return Rint(0); }
  static Rint mul_identity() { return Rint(1); }

  Rint inv() { return pow(mod - 2); }

  Rint& operator+=(Rint a) { v += a.v; if (v >= mod)v -= mod; return *this; }
  Rint& operator-=(Rint a) { v += mod - a.v; if (v >= mod)v -= mod; return *this; }
  Rint& operator*=(Rint a) { v = 1LL * v * a.v % mod; return *this; }
  Rint& operator/=(Rint a) { return (*this) *= a.inv(); }

  Rint operator+(Rint a) const { return Rint(v) += a; }
  Rint operator-(Rint a) const { return Rint(v) -= a; }
  Rint operator*(Rint a) const { return Rint(v) *= a; }
  Rint operator/(Rint a) const { return Rint(v) /= a; }

  Rint operator-() const { return v ? Rint(mod - v) : Rint(v); }

  bool operator==(const Rint a)const { return v == a.v; }
  bool operator!=(const Rint a)const { return v != a.v; }
  bool operator <(const Rint a)const { return v < a.v; }
};
template<typename T> T Rint<T>::mod;
template<typename T>
ostream& operator<<(ostream& os, Rint<T> m) { os << m.v; return os; }

// find (x, y) s.t. ax + by = gcd(a, b)
// |x| <= b, |y| <= a
// return gcd(a, b)
template<typename T>
T extgcd(T a, T b, T& x, T& y) {
  T d = a;
  if (b != 0) {
    d = extgcd(b, a % b, y, x);
    y -= (a / b) * x;
  }
  else {
    x = 1; y = 0;
  }
  return d;
}

// a, MOD coprime
template<typename T>
T mod_inverse(T a, const T MOD) {
  T x, y;
  extgcd(a, MOD, x, y);
  return (x % MOD + MOD) % MOD;
}

template<typename T, size_t sz>
struct Combination {
  using ll = long long;
  array<T, sz> fact;

  T mod;
  Combination(T mod) :mod(mod) { init(); }

  void init() {
    fact[0] = 1;
    for (int i = 1; i < (int)sz; i++)
      fact[i] = (ll)fact[i - 1] * i % mod;
  }

  T mod_fact(T n, T& e) {
    e = 0;
    if (n == 0) return 1;
    T res = mod_fact(n / mod, e);
    e += n / mod;
    if (n / mod % 2 != 0)return res * (mod - fact[n % mod]) % mod;
    return res * fact[n % mod] % mod;
  }

  T mod_comb(T n, T k) {
    if (n == k or k == 0) return 1;
    T e1, e2, e3;
    T a1 = mod_fact(n, e1), a2 = mod_fact(k, e2), a3 = mod_fact(n - k, e3);
    if (e1 > e2 + e3) return 0;
    return a1 * mod_inverse<ll>((ll)a2 * a3 % mod, mod) % mod;
  }
};

using M = Rint<ll>;
using Comb = Combination<ll, 4000>;

void solve(int n, int m) {
  M::set_mod(m);
  Comb comb(m);

  M res = 0;
  for (int i = 1; i < n; i++) {
    int a = i, b = n - i;

    M part_res = 0;
    for (int set_size = i; set_size >= 1; set_size--) {
      var t = (M(2).pow(set_size) - 1).pow(b);

      var cnt = comb.mod_comb(i, set_size);
      var sign = M(-1).pow(i - set_size);

      part_res += t * cnt * sign;
    }

    part_res *= M(2).pow(b * (b - 1) / 2) * M(2).pow(a * (a - 1) / 2);
    part_res *= comb.mod_comb(n, a);
    res += part_res;
  }

  cout << res << endl;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  int n, m;
  cin >> n >> m;
  solve(n, m);
}


