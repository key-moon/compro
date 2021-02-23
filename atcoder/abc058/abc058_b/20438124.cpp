// detail: https://atcoder.jp/contests/abc058/submissions/20438124
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  string t;
  cin >> s >> t;
  for (int i = 0; i < t.size(); i++) {
    cout << s[i] << t[i];
  }
  if (s.size() > t.size()) cout << s.back();
  cout << endl;
}
