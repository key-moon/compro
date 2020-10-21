// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2614/judge/4930545/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

using uint = unsigned int;

template<typename T, T MOD, T B>
struct RollingHash {
  using ll = long long;
  vector<T> hash, po;
  RollingHash() {}
  RollingHash(vector<T> vs) { init(vs); }
  RollingHash(string &s) {
    vector<T> vs;
    for (char c : s) vs.emplace_back(c);
    init(vs);
  }

  void init(vector<T> vs) {
    int n = vs.size();
    hash.assign(n + 1, 0);
    po.assign(n + 1, 1);
    for (int i = 0; i < n; i++) {
      hash[i + 1] = ((ll)hash[i] * B + vs[i]) % MOD;
      po[i + 1] = (ll)po[i] * B % MOD;
    }
  }
  
  T find(int l, int r) {
    T res = (ll)hash[r] + MOD - (ll)hash[l] * po[r - l] % MOD;
    return res >= MOD ? res - MOD : res;
  }
};

using RH = RollingHash<uint, 998244353, 1000000007>;

signed main() {
  string s;
  string t;
  cin >> s >> t;
  int sl = s.size();
  int tl = t.size();
  var sh = RH(s);
  var th = RH(t);
  int sq = 512;
  int res = 0;
  var gh = [&](RH& hash, int begin, int end){
    return hash.find(begin, end);
  };
  for (int i = 0; i <= sl - tl; i++){
    if (gh(sh, i, i + tl) == gh(th, 0, tl)) continue;

    int valid = 0, invalid = tl;
    while (invalid - valid > 1){
      var mid = (valid + invalid) / 2;
      if (gh(sh, i, i + mid) == gh(th, 0, mid)) valid = mid;
      else invalid = mid;
    }
    if (gh(sh, i + invalid, i + tl) == gh(th, invalid, tl)) {
      res++;
    }
  }
  cout << res << endl;
}

