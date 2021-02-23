// detail: https://atcoder.jp/contests/arc098/submissions/20449853
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n; string s;
  cin >> n >> s;
  vector<int> back(n + 1);
  for (int i = n - 1; i >= 0; i--) {
    back[i] = back[i + 1];
    if (s[i] == 'E') back[i]++;
  }
  int res = INT_MAX;
  int cnt = 0;
  for (int i = 0; i < n; i++) {
    chmin(res, back[i + 1] + cnt);
    if (s[i] == 'W') cnt++;
  }
  cout << res << endl;
}
