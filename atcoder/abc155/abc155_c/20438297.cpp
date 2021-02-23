// detail: https://atcoder.jp/contests/abc155/submissions/20438297
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
  map<string, int> cnt{};
  int mx = 0;
  for (int i = 0; i < n; i++) {
    string s;
    cin >> s;
    cnt[s]++;
    chmax(mx, cnt[s]);
  }
  for (var&& a : cnt) {
    if (mx == a.second) cout << a.first << endl;
  }
}
