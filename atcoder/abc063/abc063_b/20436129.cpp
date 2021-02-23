// detail: https://atcoder.jp/contests/abc063/submissions/20436129
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  unordered_set<int> st{};
  for (var&& c : s) {
    if (st.count(c)) {
      cout << "no" << endl;
      return 0;
    }
    st.insert(c);
  }
  cout << "yes" << endl;
}