// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2965/judge/6015651/C++17
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

using M = Rint<int>;

ll naive(int n, int k, int m) {
  vector<int> group(n * 2);
  for (int i = n; i < n * 2; i++) {
    group[i] = 1;
  }
  ll res = 0;
  vector<vector<int>> rows(2, vector<int>(n));
  int inds[2];
  do
  {
    inds[0] = 0;
    inds[1] = 0;
    for (int i = 0; i < n * 2; i++) {
      var id = group[i];
      rows[id][inds[id]] = i;
      if (inds[id] != 0) {
        var d = rows[id][inds[id]] - rows[id][inds[id] - 1];
        if (k < d) goto invalid;
      }
      inds[id]++;
    }
    for (int i = 0; i < n; i++) {
      if (rows[0][i] >= rows[1][i]) goto invalid;
      if (k < rows[1][i] - rows[0][i]) goto invalid;
    }
    res++;
  invalid:;
  } while (next_permutation(group.begin(), group.end()));
  return res % m;
}

ll solve(int n, int k, int m) {
  M::mod = m;

  vector<int> msb_table(1 << (k + 1));
  vector<int> nxtmsb_table(1 << (k + 1));
  for (int i = 0; i <= k; i++) {
    for (int b = (1 << i); b < (1 << (i + 1)); b++) {
      for (int j = i + 1; j <= k; j++) {
        nxtmsb_table[b | 1 << j] = 1 << i;
      }
      msb_table[b] = 1 << i;
    }
  }

  vector<vector<vector<M>>> dp(n + 1, vector<vector<M>>(n + 1, vector<M>(1 << k)));
  dp[1][0][1] = 1;
  for (int i = 1; i <= n; i++) {
    for (int j = 0; j <= i; j++) {
      if (k < i - j) continue;
      if (j != 0 && k == i - j) continue;
      for (int b = 0; b < (1 << k); b++) {
        if (i > j) {
          if (not(i == j + 1 && i != n && (b >> (k - 1) & 1))) {
            dp[i][j + 1][(b - msb_table[b]) << 1] += dp[i][j][b];
          }
        }
        if (i != n && not (b >> (k - 1) & 1)) {
          dp[i + 1][j][b << 1 | 1] += dp[i][j][b];
        }
      }
    }
  }

  return dp[n][n][0].v;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);

  //for (int i = 1; i < 5; i++) {
  //  for (int j = 1; j < 10; j++) {
  //    var res = solve(i, j, 1e9 + 7);
  //    var ans = naive(i, j, 1e9 + 7);
  //    if (res != ans) {
  //      printf("%d %d\nexpected: %d\n  actual: %d\n", i, j, ans, res);
  //    }
  //  }
  //}

  int n, k, m;
  cin >> n >> k >> m;
  cout << solve(n, k, m) << endl;
}

