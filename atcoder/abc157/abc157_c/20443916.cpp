// detail: https://atcoder.jp/contests/abc157/submissions/20443916
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m;
  cin >> n >> m;
  string s = n == 1 ? "0" : '1' + string(n - 1, '0');
  vector<bool> hasC(n);
  for (int i = 0; i < m; i++) {
    int ind, c;
    cin >> ind >> c;
    c += '0';
    ind--;
    if (hasC[ind] && s[ind] != c) {
      cout << -1 << endl;
      return 0;
    }
    hasC[ind] = true;
    s[ind] = c;
  }
  if (n != 1 && s[0] == '0') {
    cout << -1 << endl;
    return 0;
  }
  cout << s << endl;
}
