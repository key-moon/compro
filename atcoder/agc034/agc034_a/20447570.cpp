// detail: https://atcoder.jp/contests/agc034/submissions/20447570
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, a, b, c, d;
  cin >> n >> a >> b >> c >> d;
  string s;
  cin >> s;
  s = "#" + s + "####";
  if (a > b) {
    swap(a, b);
    swap(c, d);
  }
  var flag = false;
  vector<bool> arr1(n + 10);
  arr1[a] = true;
  for (int i = a; i <= c; i++) {
    if (s[i] == '#' || !arr1[i]) continue;
    if (s[i + 1] == '.') arr1[i + 1] = true;
    if (s[i + 2] == '.') arr1[i + 2] = true;
  }
  vector<bool> arr2(n + 10);
  arr2[b] = true;
  for (int i = b; i <= d; i++) {
    if (s[i] == '#' || !arr2[i]) continue;
    if (s[i - 1] == '.' && s[i + 1] == '.') flag = true;
    if (s[i + 1] == '.') arr2[i + 1] = true;
    if (s[i + 2] == '.') arr2[i + 2] = true;
  }
  //snuke: a    c
  //fnuke:  b  d
  if (d < c && !flag) {
    cout << "No" << endl;
    return 0;
  }
  cout << (arr1[c] && arr2[d] ? "Yes" : "No") << endl;
}
