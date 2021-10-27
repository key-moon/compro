// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2934/judge/6005453/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

template<typename T, T MOD, T B>
struct RollingHash {
  using ll = long long;
  vector<T> hash, po;
  RollingHash(vector<T> vs) { init(vs); }
  RollingHash(string& s) {
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
  //S[l, r)
  T find(int l, int r) {
    T res = (ll)hash[r] + MOD - (ll)hash[l] * po[r - l] % MOD;
    return res >= MOD ? res - MOD : res;
  }
};

using rollinghash = RollingHash<uint64_t, 998244353, 20211027>;


int main() {
  int n;
  cin >> n;
  string t;
  cin >> t;
  var revt = t;
  reverse(revt.begin(), revt.end());

  rollinghash t_rh(t);
  rollinghash revt_rh(revt);
  var get_hash = [&](int l, int r) {
    assert(l <= r);
    // return t.substr(l, r - l);
    return t_rh.find(l, r);
  };
  var get_revhash = [&](int l, int r) {
    assert(l <= r);
    // return revt.substr(n - r, r - l);
    return revt_rh.find(n - r, n - l);
  };

  // 循環節の長さは i * 2 - 2
  vector<bool> is_valid(n + 1, false);
  is_valid[n] = true;
  int res = n;
  for (int len = n - 1; len >= 1; len--) {
    var recLen = min(len * 2 - 2, n);
    var tailLen = recLen - len;
    
    var headhash = get_hash(len - (tailLen + 1), len);
    var tailhash = get_revhash(recLen - (tailLen + 1), recLen);

    if (headhash != tailhash) continue;
    
    var afterLen = min(recLen, n - recLen);
    var rechash = get_hash(0, afterLen);
    var afterhash = get_hash(recLen, recLen + afterLen);

    if (rechash != afterhash) continue;
    is_valid[len] = is_valid[min(len * 2 - 1, n)];
    if (is_valid[len]) res = len;
  }
  cout << res << endl;
}


