// detail: https://atcoder.jp/contests/abc059/submissions/20437259
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string a;
  string b;
  cin >> a >> b;
  int res = 0;
  if (a.size() > b.size()) {
    res = 1;
  }
  if (a.size() < b.size()) {
    res = -1;
  }
  if (a.size() == b.size()) {
    if (a > b) res = 1;
    if (a < b) res = -1;
  }
  if (res == 1) cout << "GREATER" << endl;
  if (res == -1) cout << "LESS" << endl;
  if (res == 0) cout << "EQUAL" << endl;
}
