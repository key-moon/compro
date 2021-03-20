// detail: https://atcoder.jp/contests/abc196/submissions/21113660
#pragma GCC target("avx512dq")
#pragma GCC optimize("O3")

#include<bits/stdc++.h>
using ll = long long;
using ull = unsigned long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

ull popcnt(ull n) {
  n = (n & 0x5555555555555555ULL) + (n >> 1 & 0x5555555555555555ULL);
  n = (n & 0x3333333333333333ULL) + (n >> 2 & 0x3333333333333333ULL);
  return (((n + (n >> 4)) & 0x0F0F0F0F0F0F0F0FULL) * 0x0101010101010101ULL >> 56 & 0x7f);
}

const int MAX_S = 1000000;
ull SS[64][(MAX_S >> 6) + 3];
ull T[(MAX_S >> 6) + 3];

int n, m;

int main() {
  string s, t;
  cin >> s >> t;
  n = s.size();
  m = t.size();
  for (int i = 0; i < n; i++) {
    if (s[i] == '0') continue;
    for (int j = 0; j <= min(i, 63); j++) {
      var ind = i - j;
      SS[j][ind >> 6] |= 1ULL << (ind & 63);
    }
  }
  for (int i = 0; i < m; i++) {
    if (t[i] == '0') continue;
    T[i >> 6] |= 1ULL << (i & 63);
  }
  var precnt = m >> 6;
  var mask = (1ULL << (m & 63)) - 1;
  ull res = UINT64_MAX;
  for (int i = 0; i <= n - m; i++) {
    ull curres = 0;
    for (int j = 0; j < precnt; j++) {
      curres += popcnt(SS[i & 63][(i >> 6) + j] ^ T[j]);
    }
    curres += popcnt((SS[i & 63][(i >> 6) + precnt] ^ T[precnt]) & mask);
    chmin(res, curres);
  }
  cout << res << endl;
}
