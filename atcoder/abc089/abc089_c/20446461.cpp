// detail: https://atcoder.jp/contests/abc089/submissions/20446461
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  var march = "MARCH";
  vector<ll> cnt(256);
  for (int i = 0; i < n; i++) {
    string s;
    cin >> s;
    cnt[s[0]]++;
  }
  ll res = 0;
  for (int i = 0; i < 5; i++) {
    for (int j = i + 1; j < 5; j++) {
      for (int k = j + 1; k < 5; k++) {
        res += cnt[march[i]] * cnt[march[j]] * cnt[march[k]];
      }
    }
  }
  cout << res << endl;
}
