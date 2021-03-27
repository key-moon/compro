// detail: https://atcoder.jp/contests/utpc2020/submissions/21283546
#include<bits/stdc++.h>

#include<atcoder/convolution.hpp>

using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;
using namespace atcoder;

using mint = modint998244353;
const int MOD = 998244353;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

template<typename V>
V compress(V vs) {
  sort(vs.begin(), vs.end());
  vs.erase(unique(vs.begin(), vs.end()), vs.end());
  return vs;
}
template<typename T>
map<T, int> dict(const vector<T>& vs) {
  map<T, int> res;
  for (int i = 0; i < (int)vs.size(); i++)
    res[vs[i]] = i;
  return res;
}
map<char, int> dict(const string& s) {
  return dict(vector<char>(s.begin(), s.end()));
}


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

Combination<int, 200000> cmb(MOD);

int solve(int N, int K, vector<int> M) {
  var val = compress(M);
  var comp = dict(val);
  var n = comp.size();

  vector<int> cnt(n + 1);
  for (int i = 0; i < N; i++) cnt[comp[M[i]]]++;

  vector<mint> inv(val.size());
  for (int i = 0; i < val.size(); i++) inv[i] = 1 / mint(val[i]);

  val.emplace_back(0);
  vector<pair<vector<mint>, vector<mint>>> polys;
  for (int i = n - 1; i >= 0; i--) {
    vector<mint> f;
    vector<mint> g;
    for (int j = 0; j <= cnt[i]; j++) {
      f.emplace_back(cmb.mod_comb(cnt[i], cnt[i] - j) * inv[i].pow(j));
      g.emplace_back(f[j] * (val[i] - (i == 0 ? 0 : val[i - 1])));
    }
    if (K + 1 < f.size()) f.resize(K + 1);
    if (K + 1 < g.size()) g.resize(K + 1);
    polys.emplace_back(g, f);
  }

  while (polys.size() > 1) {
    var k = polys.size();
    if (k & 1) {
      polys.emplace_back(vector<mint>{ 0 }, vector<mint>{ 1 });
      k++;
    }
    vector<pair<vector<mint>, vector<mint>>> newPolys;
    for (int i = 0; i < k; i += 2) {
      var&& [sum1, prod1] = polys[i];
      var&& [sum2, prod2] = polys[i + 1];

      var sumNew = convolution(prod1, sum2);
      if (K + 1 < sumNew.size()) sumNew.resize(K + 1);
      for (int j = 0; j < sum1.size(); j++) {
        sumNew[j] += sum1[j];
      }
      var prodNew = convolution(prod1, prod2);
      if (K + 1 < prodNew.size()) prodNew.resize(K + 1);
      newPolys.emplace_back(sumNew, prodNew);
    }
    polys = move(newPolys);
  }

  var res = polys[0].first.size() <= K ? 0 : polys[0].first[K];
  var all = cmb.mod_comb(N, K);
  res /= mint(all);

  return res.val();
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  /*mt19937 mt(1337);
  while (true)
  {
    uniform_int_distribution<int> nd(1, 2000);
    int n = nd(mt);
    uniform_int_distribution<int> kd(1, n);
    int k = kd(mt);
    uniform_int_distribution<int> md(1, 1e2);
    vector<int> M;
    for (int i = 0; i < n; i++) M.emplace_back(md(mt));
    solve(n, k, M);
  }*/

  int N, K;
  cin >> N >> K;
  vector<int> M(N);
  for (var&& elem : M) cin >> elem;
  var res = solve(N, K, M);
  cout << res << endl;
}
