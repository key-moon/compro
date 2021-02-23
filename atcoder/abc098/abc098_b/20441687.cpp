// detail: https://atcoder.jp/contests/abc098/submissions/20441687
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
  string s;
  cin >> s;
  int mx = 0;
  for (int i = 0; i <= n; i++) {
    unordered_set<char> st{};
    for (var&& c : s.substr(0, i)) {
      st.insert(c);
    }
    int res = 0;
    for (var&& c : s.substr(i)) {
      if (st.count(c)) {
        st.erase(c);
        res++;
      }
    }
    chmax(mx, res);
  }
  cout << mx << endl;
}
