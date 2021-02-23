// detail: https://atcoder.jp/contests/abc042/submissions/20438980
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, l;
  cin >> n >> l;
  vector<string> ss(n);
  for (int i = 0; i < n; i++) {
    cin >> ss[i];
  }
  sort(ss.begin(), ss.end());
  for (var&& s : ss) cout << s;
  cout << endl;
}
